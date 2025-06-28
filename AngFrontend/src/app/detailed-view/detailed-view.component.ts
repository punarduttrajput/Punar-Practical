import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatListModule } from '@angular/material/list';
import { ObservationService } from '../services/observation.service';

@Component({
  selector: 'app-detailed-view',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatListModule],
  templateUrl: './detailed-view.component.html',
  styleUrls: ['./detailed-view.component.css']
})
export class DetailedViewComponent implements OnInit {
  observation: any;
  selectedData: any;
  form!: FormGroup;

  constructor(private obsService: ObservationService, private fb: FormBuilder) { }

  ngOnInit() {
    this.obsService.getObservation().subscribe(data => {
      this.observation = data;
      console.log('Detailed view data:', this.observation);
    });
  }

  onSelect(samplingTime: string) {
    this.selectedData = this.observation.datas.find((d: any) => d.samplingTime === samplingTime);

    const formGroup: any = {};
    this.selectedData.properties.forEach((prop: any) => {
      formGroup[prop.label] = [prop.value];
    });

    this.form = this.fb.group(formGroup);
  }

  onSave() {
    this.selectedData.properties.forEach((prop: any) => {
      prop.value = this.form.value[prop.label];
    });

    this.obsService.saveObservation(this.observation).subscribe(() => {
      alert('Data saved!');
    });
  }
}
