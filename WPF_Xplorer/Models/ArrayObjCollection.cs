﻿using pdftron.SDF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Xplorer.Models
{
    public class ArrayObjCollection: IEnumerable<KeyValuePair<string, Obj>>, IDisposable
    {
        private readonly Obj arrayObj;
        private readonly string ancestorName;

        public ArrayObjCollection(Obj array, string ancestorName)
        {
            arrayObj = array;
            this.ancestorName = ancestorName;
        }


        public IEnumerator<KeyValuePair<string, Obj>> GetEnumerator()
        {
            return new ArrayEnumerator(arrayObj, ancestorName);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            arrayObj.Dispose();
        }
    }

    public class ArrayEnumerator : IEnumerator<KeyValuePair<string, Obj>>
    {
        private readonly Obj arrayObj;
        private readonly string ancestorName;
        private readonly int size;
        private int position = -1;


        public ArrayEnumerator(Obj array, string ancestorName)
        {
            arrayObj = array;
            size = array.Size();
            this.ancestorName = ancestorName;
        }


        public bool MoveNext()
        {
            position++;

            return position < size;
        }

        public void Reset()
        {
            position = -1;
        }

        public KeyValuePair<string, Obj> Current
        {
            get
            {
                var value = arrayObj.GetAt(position);

                var dict = new Dictionary<string, Obj>()
                {
                    {GetName(value), value}
                };

                return dict.First();
            }
        }

        private string GetName(Obj obj)
        {
            try
            {
                return obj.GetName();
            }
            catch
            {
                return $"{ancestorName}[{position}]";
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            arrayObj.Dispose();
        }
    }

}
