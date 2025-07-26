import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-positions-report',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './positions-report.html',
  styleUrls: ['./positions-report.css']
})
export class PositionsReport implements OnInit {
  positions: any[] = [];

  constructor(private api: ApiService) { }

  ngOnInit() {
    this.api.getPositions().subscribe(data => {
      this.positions = data;
    });
  }
}
