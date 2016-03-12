using System.Drawing;

namespace Gmap.net.Overlays
{
    /// <summary>
    /// a nessassary parent class for any overlay such as polyshapes
    /// </summary>
    public abstract class Overlay:Common
    {

        public Overlay(string id):base(id)
        {
        }

        private float _strokeopacity = 1f;

        /// <summary>
        /// define edge colors
        /// </summary>
        public Color StrokeColor { get; set; }

        /// <summary>
        /// define opacity or transparency value of edge color
        /// </summary>
        public float StrokeOpacity
        {

            get
            {
                return _strokeopacity;
            }
            set
            {
                if (value > 1f)
                {
                    _strokeopacity = 1f;
                }
                else if (value < 0f)
                {
                    _strokeopacity = 0f;
                }
                else
                    _strokeopacity = value;

            }
        }

        /// <summary>
        /// defing border thickness
        /// </summary>
        public int StrokeWeight { get; set; }


        /// <summary>
        /// allow to user that he could edit your shape and change overlay area
        /// </summary>
        public bool Editable { get; set; }
    }
}
