using System;
using Cards_Manager.ViewModels;
using Xamarin.Forms;
using Cards_Manager.Enums;
using Cards_Manager.Models;

namespace Cards_Manager.Selectors
{
    public class CardItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CreditTemplate { get; set; }
        public DataTemplate CryptoTemplate { get; set; }
        public DataTemplate TicketTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item switch
            {
                CreditCard => CreditTemplate,
                CryptoCard => CryptoTemplate,
                Ticket => TicketTemplate,
                _ => throw new NotImplementedException()
            };
        }
    }
}
