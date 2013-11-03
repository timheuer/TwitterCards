using System.Web;
using Subtext.Framework;
using Subtext.Framework.Components;
using Subtext.Framework.Data;
using Subtext.Web.UI.Controls;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace TwitterCards
{
    public class TwitterSummaryCard : BaseControl
    {
        protected override void Render(HtmlTextWriter writer)
        {
            //var ctx = Parent.Page
            SubtextContext ctx = base.SubtextContext as SubtextContext;

            if (ctx != null)
            {
                HtmlMeta summaryTitleMeta = new HtmlMeta();
                summaryTitleMeta.Name = "twitter:title";

                HtmlMeta descriptionMeta = new HtmlMeta();
                descriptionMeta.Name = "twitter:description";

                Entry entry = Cacher.GetEntryFromRequest(true, ctx);

                if (entry != null)
                {
                    string title = entry.Title;
                    string description = entry.HasDescription ? entry.Description : entry.Body;

                    summaryTitleMeta.Content = title;
                    var maxLen = (description.Length > 180) ? 180 : description.Length;
                    var cleanedDescription = 
                        HttpUtility.HtmlDecode(Regex.Replace(description, "<[^>]*(>|$)", string.Empty));
                    descriptionMeta.Content = cleanedDescription.Substring(0, maxLen) + "...";
                }
                else
                {
                    // get the default title/summary from the blog
                    summaryTitleMeta.Content = ctx.Blog.Title;
                    descriptionMeta.Content = ctx.Blog.SubTitle;
                }
                summaryTitleMeta.RenderControl(writer);
                descriptionMeta.RenderControl(writer);
            }
        }
    }
}
