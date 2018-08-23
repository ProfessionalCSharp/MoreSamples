import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent {
  public books: Book[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Book[]>(baseUrl + 'api/BooksFunction').subscribe(result => {
      this.books = result;
      console.log("retrieved" + this.books);
      console.log("title: " + this.books[0].title);
    }, error => console.error(error));
  }
}

interface Book {
  bookId: number;
  title: string;
  publisher: string;
}
