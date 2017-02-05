using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpriteSorter
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(SpriteRenderer))]
    public static class SpriteSorting : object
    {

        private const int IsometricRangePerYUnit = 5;

        // Update is called once per frame
        public static void SortByY( GameObject IsometricObject, int Offset = 0 )
        {
            SpriteRenderer sr = IsometricObject.GetComponent<SpriteRenderer>();
            sr.sortingOrder = -(int)(IsometricObject.transform.position.y * IsometricRangePerYUnit + Offset);
        }
    }
}
