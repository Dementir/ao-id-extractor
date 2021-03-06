﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ao_id_extractor.Helpers
{
  public class MultiTextWriter : TextWriter
  {
    private readonly IEnumerable<TextWriter> writers;

    public MultiTextWriter(IEnumerable<TextWriter> writers)
    {
      this.writers = writers.ToList();
    }

    public MultiTextWriter(params TextWriter[] writers)
    {
      this.writers = writers;
    }

    public override void Write(char value)
    {
      foreach (var writer in writers)
        writer.Write(value);
    }

    public override void Write(string value)
    {
      foreach (var writer in writers)
        writer.Write(value);
    }

    public override void Flush()
    {
      foreach (var writer in writers)
        writer.Flush();
    }

    public override void Close()
    {
      foreach (var writer in writers)
        writer.Close();
    }

    public override Encoding Encoding
    {
      get { return Encoding.ASCII; }
    }
  }
}
