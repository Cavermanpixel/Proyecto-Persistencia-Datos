using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class records : IEquatable<records>, IComparable<records>
{
    public string nameRecords;
    public int puntosRecords;

    public override string ToString()
    {
        return "   Name:      " + nameRecords + "    Puntos:    " + puntosRecords;
    }
    public int CompareTo(records comparePart)
    {
        // A null value means that this object is greater.
        if (comparePart == null)
            return 1;

        else
            return this.puntosRecords.CompareTo(comparePart.puntosRecords);
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        records objAsPart = obj as records;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }
    public override int GetHashCode()
    {
        return puntosRecords;
    }
    public bool Equals(records other)
    {
        if (other == null) return false;
        return (this.puntosRecords.Equals(other.puntosRecords));
    }
}
