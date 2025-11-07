import { Component } from '@angular/core';
import { CourseService } from '../../services/course';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-course-create',
  imports:[FormsModule],
  templateUrl: './course-create.html',
  styleUrl: './course-create.css'
})
export class CourseCreate  {
  model={
    title:'',
    description:'',
    instructorId:1
  };

  constructor(private courseService:CourseService){}

  createCourse(){
    this.courseService.create(this.model).subscribe(()=>{
      alert("Courseated!");
    });
  }

}
