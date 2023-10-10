using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SiteLanches.TagHelprs
{
    public class EmailTagHelper:TagHelper
    {
        public string Endereco { get; set; }
        public string Conteudo { get; set; }

        //metodo
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName= "a";//usando o a porque será usado um link
            output.Attributes.SetAttribute("href", "Flavio:" + Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
