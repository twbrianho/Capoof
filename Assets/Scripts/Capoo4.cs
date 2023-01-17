using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo4 : CapooBase
{
    public override float maxSize { get => 0.7f; }
    public override int mergeScore { get => 500; }
    public override string capooTag { get => "Capoo4"; }
    public override string nextCapooTag { get => "Capoo5"; }
}
