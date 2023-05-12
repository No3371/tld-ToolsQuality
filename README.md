## Tools Quality
Mod for TLD (The long dark)

This Mod allows You to:
* modify time to perform actions like wood (branches/limbs) and carcass harvesting
* modify time to perfom actions based on tool quality, separate for manufactured tools, primitive tools and hacksaw.
* Manufactured tools, can have time bonus if keept at high quality.


### Mod concept
Issue: In TLD tools quality are ignored and it's pointless to keep them maintained.

* Quality of tool will affect it's efficiency (time to complete task)
* Improvised tools have lower top efficiency but higher bottom one while compared to manufactured ones
* Manufactured tools can have "boost" efficiency above certain threshold
* Manufactured tools get inoperable below certain threshold while crude will work on minimal efficiency (do not get destroyed)
* Add stone tool(s) - it's efficiency is lower than any other tools
* (optional) Struggle tweaks - damage is scaled based on all above.
* Deprecate "QuickerWoodCutting" and add it to this (as base) and perhaps extend functionality to animal harvesting.


Lets say efficiency is arbitrary number from 0 (does not work) to 400, where vanilla manufactured tool is working on 300, improvised is 200. 
Improvised tool at 0% (well 5% if we go with path that they do not get broken) it's efficiency will be 100, while at 100% will be 200.
Manufactured at 0% efficiency is 0, at Y% is 50 (where Y is low threshold / breaking point), at X% is 300 (where X is threshold up to where degradation starts).
If boost is enabled, there is also Z% - if quality is above Z%, tool efficiency can go above 300. Disabling boost will be done by setting it to 100%.
0% > Y% > X% > Z% >= 100%

![graphs](/TQ_graph1.png)

#### Stone/bone tools (fututre proposal)

(CC @TheDev for model permission)
I would simplify Stone tools to single tool - "sharp stone" and define it as hatchet.
This way it could be used for harvesting and wood chopping.
Creating two tools (knife and hatchet) is bit pointless. Knife would be mentioned sharp stone while stone hatchet would be stick + sharp stone + tiding (line, gut, cloth).
Because stick is very weak this would be very low condition item and in end would be destroyed anyway.

Single item idea IMO works better:
* You can carve meet and skin with it - for simplicity we will ignore fact that it would damage all resulting items and just make it painfully long.
* You can use to cut those small trees (saplings?) - it will be more of "cutting them with blunt knife" than hacking so extend some time
* branches and bushes should be more less same as they are very thin... perhaps just make them same time as no tool
* limbs will take time (you are bashing rock into it) and with high possibility of breaking - or very high degradation, or (preferred) RNG test to destroy this tool on use.

Proposed values:
Animal harvesting: 3-4x
Limb chopping: 4-5x
Branch/Bush chopping: 1.5-2x
Small trees: no change (for now)

#### Mod API

The mod provides an API for mods to add items to one of the following classes:
- Improvised
- Manufatured
- Hacksaw
- Extraordinary: A new class for tools that are designed to be superior and will be too op with `Manufactured` settings applied.

There are 2 ways to use the API.

##### Method 1
The first way is reference ToolsQuality and call the methods directly:
- `ToolsQuality.ToolsQualityAPI.AddImproviseds (string[] gearItemNames)`
- `ToolsQuality.ToolsQualityAPI.AddManufactureds (string[] gearItemNames)`
- `ToolsQuality.ToolsQualityAPI.AddExtraordinarys (string[] gearItemNames)`
- `ToolsQuality.ToolsQualityAPI.AddHacksaws (string[] gearItemNames)`

This makes your mod depend on ToolsQuality.


##### Method 2

The second way does not force dependency:

```csharp
void RegisterToolsQuality (params string[] gearItemNames)
{
    Type type = Type.GetType("ToolsQuality.ToolsQualityAPI, ToolsQuality");
    if (type == null)
        return;
    var m = type.GetMethod("AddImproviseds"); // or AddManufactureds, AddExtraordinarys, AddHacksaws
    if (m == null)
    {
        MelonLogger.Warning("ToolsQuality endpoint not found.");
        return;
    }
    m.Invoke(null, new object[] { gearItemNames });
}
```

Copy this method to your mod, and change the `AddImproviseds` to the class you want, then you can call it with the gear item names you want to register.