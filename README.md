# Yolo Crawler

Description:
Low-end dungeon crawler (or something of the sort)

How things work:
- All configuration files are json files

Map generation and configuration:
- Map is generated at the start of the game
- generated map size (expressed by room count) is rolled between values configured by 'RoomCountBetween' configuration property
- map layout:
    - each room has 'MinRoomNeighboursCount' - 'MaxRoomNeighboursCount' neighbours (rolled on map generation)
- room dimensions:
    - rolled on map generation individually for each room
    - both width and height are always even numbers
    - width: 4-58 tiles
    - height: 4-16 tiles
- healing shrines:
    - are spawned across the map
    - heal player 'HealingShrines.UseCountRange' times (rolled on spawn)
    - heal 'HealingShrines.HealedHitpointsBetween' HP (rolled on spawn)
    - each room has a percentage chance to spawn one shrine - rolled for each room individually on map creation - expressed by 'HealingShrines.ShrinePercentageSpawnChance' configuration property
Default map configuration file (mapConfiguration.json):
{
    "MinRoomNeighboursCount":1,
    "MaxRoomNeighboursCount":3,
    "RoomCountBetween":{"Item1":4,"Item2":10},
    "HealingShrines":{
        "UseCountRange":{"Item1":1,"Item2":2},
        "HealedHitpointsBetween":{"Item1":2,"Item2":3},
        "ShrinePercentageSpawnChance":33
    }
}

Moving around:
Default key mapping configuration file (keyMapping.json):
{
    'Quit': 'Q',
    'LeftUp': 'NumPad7',
    'Up': 'NumPad8',
    'RightUp': 'NumPad9',
    'Left': 'NumPad4',
    'Right': 'NumPad6',
    'LeftDown': 'NumPad1',
    'Down': 'NumPad2',
    'RightDown': 'NumPad3'
}

Monsters:
Spawn: Rooms spawn up to one monster on map generation.
HP: Monsters have 2 - 8 HP (rolled on spawn)
Names: Monster name is rolled on spawn, taken at random from configuration file
Example monster name configuration file (monsterNames.json):
[
    'Clayton',
    'Rat',
    'Angular',
    'EntityFramework'
]
