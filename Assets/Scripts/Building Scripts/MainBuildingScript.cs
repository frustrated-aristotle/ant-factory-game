using System.Collections.Generic;
using UnityEngine;

namespace Building_Scripts
{
    public class MainBuildingScript : MonoBehaviour
    {
        public GameObject roadLeft, roadRight, roadBottom, roadTop;
        
        public int produceAmount = 10;
        public int consumeAmount = 5;

        protected Storage storage;
        protected ContractManager contractManager;
        private ProduceDelegator produceDelegator;

        public int ProduceAmount
        {
            get => produceAmount;
            private set => produceAmount = value;
        }

        public int ConsumeAmount
        {
            get => consumeAmount;
            private set => consumeAmount = value;
        }



        private void Awake()
        {
            contractManager = GameObject.FindObjectOfType<ContractManager>();
            storage = GetComponent<Storage>();
            produceDelegator = GameObject.FindObjectOfType<ProduceDelegator>();
            produceDelegator.producers.Add(this.GetComponent<IProduce>());
        }

    }
}