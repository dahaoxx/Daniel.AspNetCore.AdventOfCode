Rope with a knot at each end, knots mark H and T
- If the H is far enough ahead the T is pulled towards the H
- H and T must always be touching
- If the H is ever two steps away, and in same row or column, T will move on step towards
- If H and T are not touching and are not in the same row or column, T will move one step diagonally  

U - Up
L - Left
D - Down
R - Right

R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2

Commands to move the H a direction X amount of steps, update T every step

     X Y
H - (3,2)
T - (4,3)
......
....T.
...H..
......
......

     X Y
H - (2,2)
T - (4,2)

......
....T.
..H...
......
......

     X Y
H - (3,2)
T - (4,2)
......
......
..HT..
......
......

Top Right = X++, Y++
Bot Right = X++, Y--
Bot Left  = X--, Y--
Top Left  = X--, Y++



