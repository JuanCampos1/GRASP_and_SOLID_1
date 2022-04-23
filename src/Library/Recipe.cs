//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public double productCost{get; set; }
        public double equipmentCost{get; set; }
        public double totalCost{get; set; }

        /*Por Expert la clase con la responsabilidad de calcular el total es Recipe, ya que es la que tiene
        el conocimiento de cada product y equipment*/
        public double GetProductionCost()
        {
            foreach (Step step in steps)
            {
                productCost = step.Input.UnitCost * step.Quantity + productCost;
                equipmentCost = step.Quantity * step.Time + equipmentCost;
            }
            totalCost = productCost + equipmentCost;
            return totalCost;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine("Coste total: " + GetProductionCost());
        }
    }
}