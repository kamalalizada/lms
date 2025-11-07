import { Component, OnInit } from '@angular/core';
import { EnrollmentService } from '../../services/enrollment';
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "../../app-routing.module";

@Component({
  selector: 'app-my-courses',
  imports: [BrowserModule, AppRoutingModule],
  templateUrl: './my-courses.html',
  styleUrl: './my-courses.css'
})
export class MyCourses implements OnInit {
  studentId=1;
  courses:any[]=[];

  constructor(private entrollmentService:EnrollmentService){}

  ngOnInit(): void {
    this.entrollmentService.getByStudentId(this.studentId).subscribe(res=>{
      this.courses=res;
    });
  }

}
