﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILEditor.Classes
{
    public class ILEObject
    {
        public ILEObject()
        {

        } 

        public ILEObject(string Lib, string Obj, string Type = "*PGM")
        {
            this.Library = Lib;
            this.Name = Obj;
            this.Type = Type;
        } 

        public string Library;
        public string Name;
        public string Type;
        public string Extension;
        public UInt32 SizeKB;
        public string Text;
        public string Owner;
        public string SrcSpf;
        public string SrcLib;
        public string SrcMbr;
    }
}
