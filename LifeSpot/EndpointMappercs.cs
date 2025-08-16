using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Text;

namespace LifeSpot
{
    public static class EndpointMapper
    {
        /// <summary>
        ///  Mapping CSS files
        /// </summary>
        public static void MapCss(this IEndpointRouteBuilder builder)
        {
            var cssFiles = new[] { "index.css" , "slider.css" };

            foreach (var fileName in cssFiles)
            {
                builder.MapGet($"/Static/CSS/{fileName}", async context =>
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "CSS", fileName);
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });
            }
        }

        /// <summary>
        ///  Mapping JS files
        /// </summary>
        public static void MapJs(this IEndpointRouteBuilder builder)
        {
            var jsFiles = new[] { "index.js", "testing.js", "about.js", "slider.js" };

            foreach (var fileName in jsFiles)
            {
                builder.MapGet($"/Static/JS/{fileName}", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", fileName);
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
            }
        }
        /// <summary>
        ///  Mapping HTML pages
        /// </summary>
        public static void MapHtml(this IEndpointRouteBuilder builder)
        {
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sidebar.html"));
            string sliderHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "slider.html"));

            builder.MapGet("/", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                var viewText = await File.ReadAllTextAsync(viewPath);

                // Download page and include needed elements
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);

                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/testing", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");

                // Download page and include needed elements
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);

                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/about", async context =>
            {
                // Full path of this file
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "about.html");

                // Download page and include needed elements
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                
                // Now file about.html have text from sidebar.html, footer.html, slider.html
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml)
                    .Replace("<!--SLIDER-->", sliderHtml);

                // Write all file as a text to response body
                await context.Response.WriteAsync(html.ToString());
            });
        }

        // Stopped here 12.08
        // Mapping Json
        public static void MapJson(this IEndpointRouteBuilder builder)
        {
            // Array of names of jsons
            var jsFiles = new[] { "images.json" };

            foreach (var fileName in jsFiles)
            {
                // Mapped each json files for app
                builder.MapGet($"/Properties/{fileName}", async context =>
                {
                    // Full path of this file
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Properties", fileName);

                    // Reads it as a text
                    var js = await File.ReadAllTextAsync(jsPath);

                    // Write all file as a text to response body
                    await context.Response.WriteAsync(js);
                });
            }
        }

        // Mapping images
        public static void MapImages(this IEndpointRouteBuilder builder)
        {
            // Array of names of photos
            var jpegFiles = new[] { "photo1.jpg", "photo2.jpeg", "photo3.jpg", "photo4.jpeg", };

            foreach (var fileName in jpegFiles)
            {
                // Mapped each photo for app
                builder.MapGet($"/Images/{fileName}", async context =>
                {
                    // Photo path
                    var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);

                    // File.ReadAllBytesAsync(imgPath) - it`s way to read file
                    // If i use ReadAllTextAsync, it`ll be use how text, but now it reads as array of bytes
                    var photo = await File.ReadAllBytesAsync(imgPath);

                    // Response.Body.WriteAsync letting download files with Stream
                    await context.Response.Body.WriteAsync(photo);
                });
            }
        }

    }
}
