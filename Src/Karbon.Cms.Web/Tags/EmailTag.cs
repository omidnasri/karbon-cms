﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Karbon.Cms.Core.Models;
using Karbon.Cms.Core.Parsers;
using Karbon.Cms.Core.Stores;

namespace Karbon.Cms.Web.Tags
{
    [KarbonTextTag("email")]
    public class EmailTag : AbstractKarbonTextTag
    {
        /// <summary>
        /// Parses the tag based upon the specified parameters.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public override string Parse(IContent currentPage, IDictionary<string, string> parameters)
        {
            var email = parameters["email"];
            var text = email;

            if (parameters.ContainsKey("subject"))
                email += ((email.IndexOf("?", StringComparison.InvariantCulture) == -1) ? "?" : "&") + "subject=" + parameters["subject"];

            if (parameters.ContainsKey("body"))
                email += ((email.IndexOf("?", StringComparison.InvariantCulture) == -1) ? "?" : "&") + "body=" + parameters["body"];

            var sb = new StringBuilder();
            sb.AppendFormat("<a href=\"mailto:{0}\"", email); // TODO: HTML encode

            if (parameters.ContainsKey("title"))
                sb.AppendFormat(" title=\"{0}\"", parameters["title"]);

            if (parameters.ContainsKey("class"))
                sb.AppendFormat(" class=\"{0}\"", parameters["class"]);

            sb.Append(">");
            sb.Append(parameters.ContainsKey("text")
                ? parameters["text"]
                : text);

            sb.Append("</a>");

            return sb.ToString();
        }
    }
}
