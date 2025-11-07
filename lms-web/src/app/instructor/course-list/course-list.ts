import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../services/course';
import { AppRoutingModule } from "../../app-routing.module";
import { BrowserModule } from "@angular/platform-browser";

@Component({
  selector: 'app-instructor-course-list',
  imports: [AppRoutingModule, BrowserModule],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList implements OnInit {
  courses:any[]=[];
  instructorId = 1;

  constructor(private courseService:CourseService){}

  ngOnInit(): void {
    this.courseService.getByInstructorId(this.instructorId).subscribe(res=>{
      this.courses=res;
    });
    
  }

}
