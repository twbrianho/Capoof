using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo2 : CapooBase
{
    public override float maxSize { get => 0.5f; }
    public override int mergeScore { get => 200; }
    public override string capooTag { get => "Capoo2"; }
    public override string nextCapooTag { get => "Capoo3"; }
}
