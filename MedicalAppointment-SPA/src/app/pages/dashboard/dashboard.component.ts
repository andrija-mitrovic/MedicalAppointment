import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js';
import { Dashboard } from 'src/app/_models/dashboard';
import { DashboardService } from 'src/app/_services/dashboard.service';

// core components
import {
  chartOptions,
  parseOptions,
  chartExample1,
  chartExample2
} from "../../variables/charts";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public datasetsNumber = new Array();
  public datasetAge = new Array();
  public data: any;
  public salesChart;
  public clicked: boolean = true;
  public clicked1: boolean = false;

  dashboard: Dashboard;

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.getDashboardData().subscribe((dashboard:Dashboard)=>{
      this.dashboard=dashboard;
      for(let i=0;i<this.dashboard.patientReport.chartData.length;i++){
        this.datasetsNumber.push(this.dashboard.patientReport.chartData[i].number);
        this.datasetAge.push(this.dashboard.patientReport.chartData[i].age);
      }
    }, error => {
      console.log(error);
    });

    var chartOrders = document.getElementById('chart-orders');

    parseOptions(Chart, chartOptions());

    var ordersChart = new Chart(chartOrders, {
      type: 'bar',
      options: {
        scales: {
          yAxes: [
            {
              ticks: {
                callback: function(value) {
                  if (!(value % 10)) {
                    //return '$' + value + 'k'
                    return value;
                  }
                }
              }
            }
          ]
        },
        tooltips: {
          callbacks: {
            label: function(item, data) {
              var label = data.datasets[item.datasetIndex].label || "";
              var yLabel = item.yLabel;
              var content = "";
              if (data.datasets.length > 1) {
                content += label;
              }
              content += yLabel;
              return content;
            }
          }
        }
      },
      data: {
        labels: this.datasetAge,
        datasets: [
          {
            label: "Number",
            data: [this.datasetsNumber]
          }
        ]
      }
    });


/*
    var ordersChart = new Chart(chartOrders, {
      type: 'bar',
      options: chartExample2.options,
      data: chartExample2.data
    });

    var chartSales = document.getElementById('chart-sales');

    this.salesChart = new Chart(chartSales, {
			type: 'line',
			options: chartExample1.options,
			data: chartExample1.data
		});
  }


  public updateOptions() {
    this.salesChart.data.datasets[0].data = this.data;
    this.salesChart.update();
  }*/
}

}
