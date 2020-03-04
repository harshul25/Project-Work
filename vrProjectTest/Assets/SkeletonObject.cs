using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    [SerializableAttribute]
    class SkeletonObject
    {
        public JointObject Head { get; set; }
        public JointObject ShoulderCenter { get; set; }
        public JointObject ShoulderLeft { get; set; }
        public JointObject ShoulderRight { get; set; }
        public JointObject Spine { get; set; }
        public JointObject HipCenter { get; set; }
        public JointObject HipLeft { get; set; }
        public JointObject HipRight { get; set; }

        public JointObject ElbowLeft { get; set; }
        public JointObject WristLeft { get; set; }
        public JointObject HandLeft { get; set; }

        public JointObject ElbowRight { get; set; }
        public JointObject WristRight { get; set; }
        public JointObject HandRight { get; set; }

        public JointObject KneeLeft { get; set; }
        public JointObject AnkleLeft { get; set; }
        public JointObject FootLeft { get; set; }

        public JointObject KneeRight { get; set; }
        public JointObject AnkleRight { get; set; }
        public JointObject FootRight { get; set; }

        public  SkeletonObject()
        {
            this.Head = new JointObject();
            this.ShoulderCenter = new JointObject();
            this.ShoulderLeft = new JointObject();
            this.ShoulderRight = new JointObject();
            this.Spine = new JointObject();
            this.HipCenter = new JointObject();
            this.HipLeft = new JointObject();
            this.HipRight = new JointObject();

            this.ElbowLeft = new JointObject();
            this.WristLeft = new JointObject();
            this.HandLeft = new JointObject();

            this.ElbowRight = new JointObject();
            this.WristRight = new JointObject();
            this.HandRight = new JointObject();

            this.KneeLeft = new JointObject();
            this.AnkleLeft = new JointObject();
            this.FootLeft = new JointObject();

            this.KneeRight = new JointObject();
            this.AnkleRight = new JointObject();
            this.FootRight = new JointObject();
        }
    }

    [SerializableAttribute]
    public class JointObject
    {
        public float x { get; set; } 
        public float y { get; set; }
        public float z { get; set; }

        public JointObject()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
    }
}
