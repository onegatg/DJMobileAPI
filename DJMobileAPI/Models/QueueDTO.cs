using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJMobileAPI.Models
{
    public class QueueDTO
    {
        public int Id { get; set; }
        public TrackDTO[] Tracks;
        public AudioFeaturesDTO[] AudioFeatures;
    }
}