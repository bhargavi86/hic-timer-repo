import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { interval, Subscription } from "rxjs";
import { SharedService } from "src/app/shared.service";

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.css']
})
export class TimerComponent implements OnInit, OnDestroy {
  time: number = 10;
  private timerSubscription: Subscription;

  constructor(private sub: ActivatedRoute, private sharedService: SharedService) {
    this.timerSubscription = Subscription.EMPTY;
  }

  ngOnInit() {
    this.refreshTimer();
  }
  
  ngOnDestroy() {
    this.timerSubscription.unsubscribe();
  }

  refreshTimer(): void {
    this.timerSubscription = interval(1000).subscribe(() => {
      this.time--;
      if (this.time == 0) {
        console.log('Timer Restarting');
        this.time = 10;
        var randomId = this.getRandomInt(1, 3);
        console.log(randomId);
        this.sharedService.incrementInventory(randomId).subscribe(result => {
          this.sharedService.sendUpdate('refresh');
        }, error => console.error(error));      
      }
    });
  }

  getRandomInt(min: number, max: number): number {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

}
