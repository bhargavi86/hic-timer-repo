import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable, Subject } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private subjectName = new Subject<any>();
  constructor(private http: HttpClient) { }

  getAllInventory(): Observable<any[]> {
    return this.http.get<any>('/api/Inventory');
  }

  getInventory(val: any): Observable<any> {
    return this.http.get<any>('/api/Inventory/'+val);
  }

  incrementInventory(val: any) {
    return this.http.put('/api/Inventory/'+val, {});
  }

  sendUpdate(message: string) { 
    this.subjectName.next({ text: message }); 
  }

  getUpdate(): Observable<any> { 
    return this.subjectName.asObservable(); 
  }
}
