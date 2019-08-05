using DataBindingSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataBindingSample.Utilities
{
    public class BookTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultBookTemplate { get; set; }
        public DataTemplate WroxBookTemplate { get; set; }

        //public override DataTemplate SelectTemplate(object item, DependencyObject container)
        //{
        //    DataTemplate selectedTemplate = null;
        //    if (item is Book book)
        //    {
        //        switch (book.Publisher)
        //        {
        //            case "Wrox Press":
        //                selectedTemplate = WroxBookTemplate;
        //                break;
        //            default:
        //                selectedTemplate = DefaultBookTemplate;
        //                break;
        //        }
        //    }
        //    return selectedTemplate;
        //}

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
            => item switch
            {
                Book { Publisher: "Wrox Press"} => WroxBookTemplate,
                Book _ => DefaultBookTemplate,
                _ => null
            };
    }
}
