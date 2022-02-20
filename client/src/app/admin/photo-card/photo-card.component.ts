import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Photo } from 'src/app/_models/photo';

@Component({
  selector: 'app-photo-card',
  templateUrl: './photo-card.component.html',
  styleUrls: ['./photo-card.component.css']
})
export class PhotoCardComponent implements OnInit {
  @Input() photo: Partial<Photo>;
  @Output() approvePhotoEvent = new EventEmitter();
  @Output() rejectPhotoEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  approvePhoto(id: number) {
    this.approvePhotoEvent.emit(id);
  }

  rejectPhoto(id: number) {
    this.rejectPhotoEvent.emit(id);
  }

}
