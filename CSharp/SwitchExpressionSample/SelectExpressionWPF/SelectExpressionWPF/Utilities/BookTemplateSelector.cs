using SelectExpressionWPF.Models;
using System.Windows;
using System.Windows.Controls;

namespace SelectExpressionWPF.Utilities
{
    public class BookTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? DefaultBookTemplate { get; set; }
        public DataTemplate? WroxBookTemplate { get; set; }
        public DataTemplate? AWLBookTemplate { get; set; }

        //    // C# 6 version 
        //    public override DataTemplate SelectTemplate(object item, DependencyObject container)
        //    {
        //        var book = item as Book;
        //        if (book == null) return null;

        //        DataTemplate selectedTemplate = null;
        //        switch (book.Publisher)
        //        {
        //            case "Wrox Press":
        //                selectedTemplate = WroxBookTemplate;
        //                break;
        //            case "AWL":
        //                selectedTemplate = AWLBookTemplate;
        //                break;
        //            default:
        //                selectedTemplate = DefaultBookTemplate;
        //                break;
        //        }
        //        return selectedTemplate;
        //    }

        //// C# 7 version using pattern matching
        //public override DataTemplate SelectTemplate(object item, DependencyObject container)
        //{
        //    if (item is Book book)
        //    {
        //        DataTemplate selectedTemplate = null;
        //        switch (book.Publisher)
        //        {
        //            case "Wrox Press":
        //                selectedTemplate = WroxBookTemplate;
        //                break;
        //            case "AWL":
        //                selectedTemplate = AWLBookTemplate;
        //                break;
        //            default:
        //                selectedTemplate = DefaultBookTemplate;
        //                break;
        //        }
        //        return selectedTemplate;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //// C# 7 version using when with case
        //public override DataTemplate SelectTemplate(object item, DependencyObject container)
        //{
        //    DataTemplate selectedTemplate = null;
        //    switch (item)
        //    {
        //        case Book b when b.Publisher == "Wrox Press":
        //            selectedTemplate = WroxBookTemplate;
        //            break;
        //        case Book b when b.Publisher == "AWL":
        //            selectedTemplate = AWLBookTemplate;
        //            break;
        //        case Book _:
        //            selectedTemplate = DefaultBookTemplate;
        //            break;
        //        default:
        //            selectedTemplate = null;
        //            break;
        //    }
        //    return selectedTemplate;
        //}

        // C# 8 with select expression and pattern matching
        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
            => item switch
            {
                Book { Publisher: "Wrox Press" } => WroxBookTemplate,
                Book { Publisher: "AWL" } => AWLBookTemplate,
                Book _ => DefaultBookTemplate,
                _ => null
            };
    }
}
