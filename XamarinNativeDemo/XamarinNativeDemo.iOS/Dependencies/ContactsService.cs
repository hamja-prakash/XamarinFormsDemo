﻿using Contacts;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using UIKit;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.Model;
using System.IO;

namespace XamarinNativeDemo.iOS.Dependencies
{
    public class ContactsService : NSObject, IContactsService
    {
        const string ThumbnailPrefix = "thumb";

        bool requestStop = false;

        public event EventHandler<ContactEventArgs> OnContactLoaded;

        bool _isLoading = false;
        public bool IsLoading => _isLoading;

        public async Task<IList<Contact>> RetrieveContactsAsync(CancellationToken? cancelToken = null)
        {
            requestStop = false;

            if (!cancelToken.HasValue)
                cancelToken = CancellationToken.None;

            // We create a TaskCompletionSource of decimal
            var taskCompletionSource = new TaskCompletionSource<IList<Contact>>();

            // Registering a lambda into the cancellationToken
            cancelToken.Value.Register(() =>
            {
                // We received a cancellation message, cancel the TaskCompletionSource.Task
                requestStop = true;
                taskCompletionSource.TrySetCanceled();
            });

            _isLoading = true;

            var task = LoadContactsAsync();

            // Wait for the first task to finish among the two
            var completedTask = await Task.WhenAny(task, taskCompletionSource.Task);
            _isLoading = false;

            return await completedTask;

        }

        public async Task<bool> RequestPermissionAsync()
        {
            var status = CNContactStore.GetAuthorizationStatus(CNEntityType.Contacts);

            Tuple<bool, NSError> authotization = new Tuple<bool, NSError>(status == CNAuthorizationStatus.Authorized, null);

            if (status == CNAuthorizationStatus.NotDetermined)
            {
                using (var store = new CNContactStore())
                {
                    authotization = await store.RequestAccessAsync(CNEntityType.Contacts);
                }
            }
            return authotization.Item1;

        }

        async Task<IList<Contact>> LoadContactsAsync()
        {
            IList<Contact> contacts = new List<Contact>();
            var hasPermission = await RequestPermissionAsync();
            if (hasPermission)
            {

                NSError error = null;
                var keysToFetch = new[] { CNContactKey.PhoneNumbers, CNContactKey.GivenName, CNContactKey.FamilyName, CNContactKey.EmailAddresses, CNContactKey.ImageDataAvailable, CNContactKey.ThumbnailImageData };

                var request = new CNContactFetchRequest(keysToFetch: keysToFetch);
                request.SortOrder = CNContactSortOrder.GivenName;

                using (var store = new CNContactStore())
                {
                    var result = store.EnumerateContacts(request, out error, new CNContactStoreListContactsHandler((CNContact c, ref bool stop) =>
                    {

                        string path = null;
                        if (c.ImageDataAvailable)
                        {
                            path = path = Path.Combine(Path.GetTempPath(), $"{ThumbnailPrefix}-{Guid.NewGuid()}");

                            if (!File.Exists(path))
                            {
                                var imageData = c.ThumbnailImageData;
                                imageData?.Save(path, true);
                            }
                        }

                        var contact = new Contact()
                        {
                            Name = string.IsNullOrEmpty(c.FamilyName) ? c.GivenName : $"{c.GivenName} {c.FamilyName}",
                            Image = path,
                            PhoneNumbers = c.PhoneNumbers?.Select(p => p?.Value?.StringValue).ToArray(),
                            Emails = c.EmailAddresses?.Select(p => p?.Value?.ToString()).ToArray(),

                        };

                        if (!string.IsNullOrWhiteSpace(contact.Name))
                        {
                            OnContactLoaded?.Invoke(this, new ContactEventArgs(contact));

                            contacts.Add(contact);
                        }

                        stop = requestStop;

                    }));
                }
            }
            return contacts;
        }
    }
}