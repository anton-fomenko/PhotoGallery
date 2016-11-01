using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// Generate string which can be applied inside class attribute of the element. Set classes for 
        /// "Like" or "Dislike buttons.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="userLiked"></param>
        /// <param name="canVote"></param>
        /// <param name="likeButton">Returns true if the helper is used for Like button.
        /// Returns False if it is used for Dislike button </param>
        /// <returns></returns>
        public static IHtmlString ButtonVoteClasses(this HtmlHelper helper, bool? userLiked, bool canVote, bool likeButton)
        {
            string returnString = String.Empty;
            string buttonClass = likeButton ? "btn-success" : "btn-danger";
            if (userLiked.HasValue)
            {
                returnString += !canVote ? buttonClass : "";
            }
            returnString += canVote ? "" : " disabled";
            return new MvcHtmlString(returnString);
        }
    }
}