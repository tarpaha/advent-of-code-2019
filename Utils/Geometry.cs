namespace Utils
{
    public static class Geometry
    {
        public static bool Intersect(Segment2 s0, Segment2 s1, out Vector2 intersection)
        {
            intersection = new Vector2();

            var divider = (s1.P1.X - s1.P0.X) * (s0.P0.Y - s0.P1.Y) - (s0.P0.X - s0.P1.X) * (s1.P1.Y - s1.P0.Y);
            if (divider == 0)
                return false;
            
            var t0 = (s1.P0.Y - s1.P1.Y) * (s0.P0.X - s1.P0.X) + (s1.P1.X - s1.P0.X) * (s0.P0.Y - s1.P0.Y);
            var t1 = (s0.P0.Y - s0.P1.Y) * (s0.P0.X - s1.P0.X) + (s0.P1.X - s0.P0.X) * (s0.P0.Y - s1.P0.Y);
 
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

            intersection.X = s0.P0.X + t0 * (s0.P1.X - s0.P0.X) / divider;
            intersection.Y = s0.P0.Y + t0 * (s0.P1.Y - s0.P0.Y) / divider;
                
            return true;
        }
        
        // returns -1 if point not on the segment
        public static int DistanceFromSegmentStart(Segment2 s, Vector2 p)
        {
            if (s.P0.Y == s.P1.Y)
            {
                // horizontal segment
                
                if (p.Y != s.P0.Y)
                    return -1;
                
                if (s.P0.X < s.P1.X)
                {
                    // from left to right
                    if (p.X < s.P0.X || p.X > s.P1.X)
                        return -1;
                    return p.X - s.P0.X;
                }
                else
                {
                    // from right to left
                    if (p.X < s.P1.X || p.X > s.P0.X)
                        return -1;
                    return s.P0.X - p.X;
                }
            }
            else
            {
                // vertical segment
                
                if (p.X != s.P0.X)
                    return -1;
                
                if (s.P0.Y < s.P1.Y)
                {
                    // from down to up
                    if (p.Y < s.P0.Y || p.Y > s.P1.Y)
                        return -1;
                    return p.Y - s.P0.Y;
                }
                else
                {
                    // from up to down 
                    if (p.Y < s.P1.Y || p.Y > s.P0.Y)
                        return -1;
                    return s.P0.Y - p.Y;
                }
            }
        }
    }
}