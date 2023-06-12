import { Component, OnInit, OnDestroy } from '@angular/core';
import { SharedService } from "src/app/shared.service";
import { Subscription } from "rxjs";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnDestroy, OnInit {
  public inventoryItems?: InventoryBO[];
  private subscription: Subscription;

  constructor(private sharedService: SharedService, private sub: ActivatedRoute) {
    this.subscription = this.sharedService.getUpdate().subscribe
      (message => {
        console.log(message.text);
        if (message.text == 'refresh') {
          console.log('We are in the refresh logic!');
          this.getInventoryList();
        }
      });
  }

 ngOnInit(): void {
      this.getInventoryList();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getInventoryList() {
    this.sharedService.getAllInventory().subscribe(result => {
      console.log('We are in the GetAllInventory method!');
      this.inventoryItems = result;
    }, error => console.error(error));
  }
}

interface InventoryBO {
  id: number;
  name: string;
  description: string;
  count: number;
}
