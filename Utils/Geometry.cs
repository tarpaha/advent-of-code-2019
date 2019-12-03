namespace Utils
{
    public static class Geometry
    {
        public static bool Intersect(Segment2 s0, Segment2 s1, out Vector2 intersection)
        {
            intersection = new Vector2();

            var divider = (s1.p1.x - s1.p0.x) * (s0.p0.y - s0.p1.y) - (s0.p0.x - s0.p1.x) * (s1.p1.y - s1.p0.y);
            if (divider == 0)
                return false;
            
            var t0 = (s1.p0.y - s1.p1.y) * (s0.p0.x - s1.p0.x) + (s1.p1.x - s1.p0.x) * (s0.p0.y - s1.p0.y);
            var t1 = (s0.p0.y - s0.p1.y) * (s0.p0.x - s1.p0.x) + (s0.p1.x - s0.p0.x) * (s0.p0.y - s1.p0.y);
 
            if (divider > 0)
            {
                if (t0 < 0 || t0 > divider || t1 < 0 || t1 > divider)
                    return false;
            }
            else
            {
                if (t0 > 0 || t0 < divider || t1 > 0 || t1 < divider)
                    return false;
            }

            intersection.x = s0.p0.x + t0 * (s0.p1.x - s0.p0.x) / divider;
            intersection.y = s0.p0.y + t0 * (s0.p1.y - s0.p0.y) / divider;
                
            return true;
        }
        
        // returns -1 if point not on the segment
        public static int DistanceFromSegmentStart(Segment2 s, Vector2 p)
        {
            if (s.p0.y == s.p1.y)
            {
                // horizontal segment
                
                if (p.y != s.p0.y)
                    return -1;
                
                if (s.p0.x < s.p1.x)
                {
                    // from left to right
                    if (p.x < s.p0.x || p.x > s.p1.x)
                        return -1;
                    return p.x - s.p0.x;
                }
                else
                {
                    // from right to left
                    if (p.x < s.p1.x || p.x > s.p0.x)
                        return -1;
                    return s.p0.x - p.x;
                }
            }
            else
            {
                // vertical segment
                
                if (p.x != s.p0.x)
                    return -1;
                
                if (s.p0.y < s.p1.y)
                {
                    // from down to up
                    if (p.y < s.p0.y || p.y > s.p1.y)
                        return -1;
                    return p.y - s.p0.y;
                }
                else
                {
                    // from up to down 
                    if (p.y < s.p1.y || p.y > s.p0.y)
                        return -1;
                    return s.p0.y - p.y;
                }
            }
        }
    }
}