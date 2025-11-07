import { Component } from '@angular/core';
import { CourseService } from '../../services/course';  

import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "../../app-routing.module";

@Component({
  selector: 'app-course-list',
  imports: [BrowserModule, AppRoutingModule],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList {
  courses: any[] = [];

  constructor(private courseService: CourseService) {} 

  ngOnInit() {
    this.courseService.getAll().subscribe((res: any) => {
      this.courses = res;
    });
  }
}
