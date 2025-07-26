import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-trade-entry',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './trade-entry.html',
  styleUrls: ['./trade-entry.css']
})
export class TradeEntry{
  trade = {
    tradeId: null,
    version: null,
    securityCode: '',
    quantity: null,
    action: '',
    buySell: ''
  };

  actions = ['INSERT', 'UPDATE', 'CANCEL'];
  buysell = ['Buy', 'Sell'];
  message = '';

  constructor(private api: ApiService) { }

  submit() {
    this.api.addTransaction(this.trade).subscribe({
      next: () => {
        this.message = 'Transaction submitted successfully!';
        this.trade = {
          tradeId: null,
          version: null,
          securityCode: '',
          quantity: null,
          action: '',
          buySell: ''
        };
      },
      error: (err) => {
        this.message = `Error: ${err.error || 'Failed to submit transaction.'}`;
      }
    });
  }
}
