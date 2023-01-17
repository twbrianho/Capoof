using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo1 : CapooBase
{
    public override float maxSize { get => 0.5f; }
    public override int mergeScore { get => 100; }
    public override string capooTag { get => "Capoo1"; }
    public override string nextCapooTag { get => "Capoo2"; }
}
