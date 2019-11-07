using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WMP.PipelineComponenets
{
    public class ArchivingStream : Stream, IDisposable
    {
        public ArchivingStream(Stream messageStream, string archivePath)
        {
            _messageStream = messageStream;
            _archiveStream = new FileStream(archivePath, FileMode.Create);
        }

        Stream _messageStream;
        FileStream _archiveStream;


        public override bool CanRead
        {
            get { return _messageStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _messageStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _messageStream.CanWrite; }
        }

        public override void Flush()
        {
            _messageStream.Flush();
        }

        public override long Length
        {
            get { return _messageStream.Length; }
        }

        public override long Position
        {
            get
            {
                return _messageStream.Position;
            }
            set
            {
                _messageStream.Position = value;
                _archiveStream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int result = _messageStream.Read(buffer, offset, count);
            _archiveStream.Write(buffer, offset, result);
            return result;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _messageStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _messageStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _messageStream.Write(buffer, offset, count);
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            _archiveStream.Close();
            _archiveStream.Dispose();
        }

        #endregion
    }
}
