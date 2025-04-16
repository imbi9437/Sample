using System.Collections.Generic;
using UnityEngine;

namespace Script.Order.Data
{
    [CreateAssetMenu(fileName = "Job", menuName = "Scriptable Objects/Job")]
    public class Job : ScriptableObject
    {
        public string id;
        public string jobName;
        public string description;

        public Job prevJob;
        public List<Job> nextJob;
    }
}