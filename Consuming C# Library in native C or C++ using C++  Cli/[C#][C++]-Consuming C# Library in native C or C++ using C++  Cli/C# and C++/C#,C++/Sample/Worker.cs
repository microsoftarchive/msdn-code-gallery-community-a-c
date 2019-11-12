using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
   /// <summary>
   /// A sample worker class in C#
   /// </summary>
   public class Worker
   {
      /// <summary>
      /// Callback method signature to send array of values.
      /// </summary>
      /// <param name="values">The values.</param>
      public delegate void FloatValuesReady(float[] values);

      /// <summary>
      /// Occurs when [float values are ready].
      /// </summary>
      public event FloatValuesReady ReadFloatValues;

      /// <summary>
      /// Sums the specified i.
      /// </summary>
      /// <param name="i">The i.</param>
      /// <param name="j">The j.</param>
      /// <returns></returns>
      public int Sum(int i, int j)
      {
         return i + j;
      }

      /// <summary>
      /// Gets the Student object.
      /// </summary>
      /// <returns></returns>
      public ManagedStudent GetStudent()
      {
         Console.WriteLine("Enter a Name:");
         string text = Console.ReadLine();
         if (text != string.Empty)
         {
            return new ManagedStudent { Name = text };
         }
         return new ManagedStudent { Name = "NoName" };
      }

      /// <summary>
      /// Read some float values from Console and give it back to the caller using ReadFloatValues callback.
      /// So Caller should add event handler to ReadFloatValues event.
      /// </summary>
      public void GetSomeFloatValues()
      {
         List<float> values = new List<float>();
         Console.WriteLine("Enter 4 valid float values for the Native App");
         while (values.Count < 4)
         {
            string valueText = Console.ReadLine();
            float value;
            if(float.TryParse(valueText, out value))
            {
               values.Add(value);
            }
         }
         if (this.ReadFloatValues != null)
         {
            this.ReadFloatValues(values.ToArray());
         }
      }
   }

   /// <summary>
   /// A Managed Class
   /// </summary>
   public class ManagedStudent
   {
      public string Name { get; set; }
   }
}
