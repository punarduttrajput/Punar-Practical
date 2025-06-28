import { Component, OnInit } from '@angular/core';
import { ObservationService } from '../services/observation.service'; // <-- Replace with your actual service import
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';

export interface ProcessedData {
  samplingTime: string;
  projectName: string;
  constructionCount: number;
  isCompleted: boolean;
  lengthOfRoad: number;
}

@Component({
  selector: 'app-summary-view',
  standalone: true,
  imports: [CommonModule, MatTableModule],
  templateUrl: './summary-view.component.html',
  styleUrls: ['./summary-view.component.css']
})
export class SummaryViewComponent implements OnInit {
  observation: any;
  processedData: ProcessedData[] = [];
  displayedColumns: string[] = ['samplingTime', 'projectName', 'constructionCount', 'isCompleted', 'lengthOfRoad'];

  constructor(private obsService: ObservationService) { }

  ngOnInit(): void {
    this.obsService.getObservation().subscribe(res => {
      this.observation = res;
      console.log('Raw observation:', this.observation);

      this.processedData = this.observation.datas.map((item: any) => ({
        samplingTime: item.samplingTime,
        projectName: item.properties.find((p: any) => p.label === 'Project Name')?.value || '',
        constructionCount: item.properties.find((p: any) => p.label === 'Construction Count')?.value || 0,
        isCompleted: item.properties.find((p: any) => p.label === 'Is Construction Completed')?.value || false,
        lengthOfRoad: item.properties.find((p: any) => p.label === 'Length of the road')?.value || 0,
      }));

      console.log('Processed data:', this.processedData);
    });
  }
}
