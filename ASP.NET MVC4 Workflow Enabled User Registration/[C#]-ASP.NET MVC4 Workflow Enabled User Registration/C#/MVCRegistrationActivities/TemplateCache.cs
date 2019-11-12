namespace MVCRegistrationActivities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal static class TemplateCache
    {
        #region Constants and Fields

        private static readonly object CacheLock = new object();

        private static readonly Dictionary<string, MailTemplate> CachedTemplates =
            new Dictionary<string, MailTemplate>();

        #endregion

        #region Methods

        internal static void AddOrUpdate(string path, MailTemplate template)
        {
            lock (CacheLock)
            {
                if (CachedTemplates.ContainsKey(path))
                {
                    CachedTemplates[path] = template;
                }
                else
                {
                    CachedTemplates.Add(path, template);
                }
            }
        }

        internal static bool CachedTemplateIsFresh(FileInfo fileInfo, MailTemplate template)
        {
            return fileInfo.Exists && fileInfo.LastWriteTime == template.LastWrite;
        }

        internal static string GetTemplate(string path, Encoding encoding)
        {
            var fullPath = Path.GetFullPath(path);
            var fileInfo = new FileInfo(fullPath);

            if (!fileInfo.Exists)
            {
                throw new InvalidOperationException("Cannot open email template");
            }

            string template;

            if (!IsCurrent(fullPath, fileInfo, out template))
            {
                template = LoadTemplate(path, encoding);
                AddOrUpdate(fullPath, new MailTemplate(fileInfo.LastWriteTime) { Template = template });
            }

            return template;
        }

        internal static bool IsCurrent(string path, FileInfo fileInfo, out string emailTemplate)
        {
            MailTemplate template;

            if (CachedTemplates.TryGetValue(path, out template) && CachedTemplateIsFresh(fileInfo, template))
            {
                emailTemplate = template.Template;
                return true;
            }

            emailTemplate = string.Empty;
            return false;
        }

        internal static string LoadTemplate(string path, Encoding encoding)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            using (
                var fileStream = new FileStream(
                    path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 0x1000, useAsync: true))
            {
                var sb = new StringBuilder();

                var buffer = new byte[0x1000];
                int numRead;
                while ((numRead = fileStream.ReadAsync(buffer, 0, buffer.Length).Result) != 0)
                {
                    var text = encoding.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }

        #endregion
    }
}