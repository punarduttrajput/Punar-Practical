import { Component } from '@angular/core';
import { MatTabsModule } from '@angular/material/tabs';
import { SummaryViewComponent } from './summary-view/summary-view.component';
import { DetailedViewComponent } from './detailed-view/detailed-view.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MatTabsModule, SummaryViewComponent, DetailedViewComponent, CommonModule],
  templateUrl: './app.component.html',
})
export class AppComponent { }
