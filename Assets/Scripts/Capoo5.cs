using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo5 : CapooBase
{
    public override float maxSize { get => 0.6f; }
    public override int mergeScore { get => 800; }
    public override string capooTag { get => "Capoo5"; }
    public override string nextCapooTag { get => "Capoo6"; }
}
