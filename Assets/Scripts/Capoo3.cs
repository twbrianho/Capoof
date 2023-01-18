using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo3 : CapooBase
{
    public override float maxSize { get => 0.55f; }
    public override int mergeScore { get => 300; }
    public override string capooTag { get => "Capoo3"; }
    public override string nextCapooTag { get => "Capoo4"; }
}
