import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface IUser {
  id: number;
  userName: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
  users: IUser[];

  constructor( private readonly httpClient: HttpClient ) {
  }

  ngOnInit(): void {
    this.getUsers();
  }

  private getUsers(): void {
    this.httpClient.get('https://localhost:5001/api/users').subscribe(
      ( response: IUser[] ) => this.users = response,
      error => console.log(error),
    );
  }
}
