// Brought to you by Jenni
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

interface IMoveableChar {
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
    void Move(Vector2 dir);
}
