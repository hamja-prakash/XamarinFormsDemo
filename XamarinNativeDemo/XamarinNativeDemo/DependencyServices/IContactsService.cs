using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using XamarinNativeDemo.Model;

namespace XamarinNativeDemo.DependencyServices
{
    public interface IContactsService
    {
        event EventHandler<ContactEventArgs> OnContactLoaded;
        bool IsLoading { get; }
        Task<IList<Contact>> RetrieveContactsAsync(CancellationToken? token = null);
    }

    public class ContactEventArgs : EventArgs
    {
        public Contact Contact { get; }
        public ContactEventArgs(Contact contact)
        {
            Contact = contact;
        }
    }
}
