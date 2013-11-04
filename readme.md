# Twitter Cards for Subtext #
This is a quick and dirty implementation for adding Twitter Summary Cards support to your Subtext blog site.

> I've only tested this on Subtext 2.5.2

See this post for more details: [http://timheuer.com/blog/archive/2013/11/03/adding-twitter-summary-cards-to-blog-content.aspx](http://timheuer.com/blog/archive/2013/11/03/adding-twitter-summary-cards-to-blog-content.aspx)

## Installation
- Build this project.  Please note this requires references to Subtext.Web and Subtext.Framework which aren't included in this project and is assumed you know how to get those.
- Take the output TwitterCards.dll and put it in your /bin directory of your Subtext 2.5.2 installation
- In your web.config in the pages\controls section add:

 	`<add tagPrefix="twitterCards" namespace="TwitterCards" assembly="TwitterCards" />`

- In your DTP.aspx file (I put this after the MetaTagsControl) add:

	`<twitterCards:TwitterSummaryCard id="twitterSummaryCard" runat="server" />`

- In Subtext Admin console go to META tags and add the following (recommended):
	- name=twitter:card, content=summary
	- name=twitter:site, content=@yourtwittername
	- name=twitter:creator, content=@yourtwittername
	- name=twitter:domain, content=http://yourdomain
	- name=twitter:image, content=full url to your logo

## What it does
This adds two META tags to your site, twitter:title, twitter:description.  On a non-post page it uses your blog name as title and blog subtitle as description, so be sure to update those correctly.

On a post page it uses the Entry.Title as title and the first 180 characters of Entry.Body as description.  If your Entry has a description it will use that first.  All HTML tags are stripped out for the META tag.

## Future
Ideally once Subtext support moves to ASP.NET 4 and stabilize I think I'll add a pull request to this control into the new model (not as-is but more integrated with Subtext model).

## Questions
Contact Tim Heuer ([@timheuer](http://twitter.com/timheuer)) [http://timheuer.com/blog](http://timheuer.com/blog/) 