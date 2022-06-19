import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
    CreateStudentDto,
    StudentServiceProxy
    ,









 UniversityDto, UniversityServiceProxy,
 CollegeDto, CollegeServiceProxy,
 MajorDto, MajorServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { NbDialogRef } from '@nebular/theme';
import { L10n, setCulture, loadCldr } from '@syncfusion/ej2-base';
import { LocalizationHelper } from '@shared/localization/localization-helper';
//import endTag

setCulture('ar-SY');
L10n.load(LocalizationHelper.getArabicResources());

@Component({
    templateUrl: 'create-student-dialog.component.html',
    styleUrls: ['create-student-dialog.component.scss'],
    providers: [StudentServiceProxy]
})
export class CreateStudentDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    student: CreateStudentDto = new CreateStudentDto();
    









universities: UniversityDto[] = [];
public universityIdFields: Object = { text: 'name', value: 'id' };

colleges: CollegeDto[] = [];
public collegeIdFields: Object = { text: 'name', value: 'id' };

majors: MajorDto[] = [];
public majorIdFields: Object = { text: 'name', value: 'id' };


    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _studentService: StudentServiceProxy,
        









private _universityAppService: UniversityServiceProxy,
private _collegeAppService: CollegeServiceProxy,
private _majorAppService: MajorServiceProxy,

        public dialogRef: NbDialogRef<CreateStudentDialogComponent>
    ) {
        super(injector);
        loadCldr(
            require("cldr-data/main/ar-SY/numbers.json"),
            require("cldr-data/main/ar-SY/ca-gregorian.json"),
            require("cldr-data/supplemental/numberingSystems.json"),
            require("cldr-data/main/ar-SY/timeZoneNames.json"),
            require('cldr-data/supplemental/weekdata.json')
        );
    }

    ngOnInit(): void {
        









this.initialUniversities();
this.initialColleges();
this.initialMajors();

    }

    save(): void {
        this.saving = true;

        this._studentService
            .create(this.student)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.dialogRef.close();
                this.onSave.emit();
            });
    }

    









initialUniversities(){
    this._universityAppService.getAll()
    .subscribe(result => this.universities = result);
}

initialColleges(){
    this._collegeAppService.getAll()
    .subscribe(result => this.colleges = result);
}

initialMajors(){
    this._majorAppService.getAll()
    .subscribe(result => this.majors = result);
}


}
