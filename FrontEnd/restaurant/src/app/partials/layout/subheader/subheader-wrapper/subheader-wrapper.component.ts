import {Component, OnInit, AfterViewInit, Input, ChangeDetectorRef} from '@angular/core';
import {Observable} from 'rxjs';
import {SubheaderService} from '../_services/subheader.service';
import {KTUtil} from '../../../../../assets/js/components/util';
import KTLayoutSubheader from '../../../../../assets/js/layout/base/subheader';
import {Router, ResolveEnd} from '@angular/router';
import {filter} from 'rxjs/operators';
import {BreadcrumbItemModel} from '../_models/breadcrumb-item.model';
import {LayoutService} from '../../../../core';

@Component({
    selector: 'app-subheader-wrapper',
    templateUrl: './subheader-wrapper.component.html',
})
export class SubheaderWrapperComponent implements OnInit, AfterViewInit {
    subheaderVersion$: Observable<string>;
    subheaderCSSClasses = '';
    subheaderContainerCSSClasses = '';
    subheaderMobileToggle = false;
    subheaderDisplayDesc = false;
    subheaderDisplayDaterangepicker = false;
    title$: Observable<string>;
    breadcrumbs$: Observable<BreadcrumbItemModel[]>;
    breadcrumbs: BreadcrumbItemModel[] = [];
    description$: Observable<string>;
    @Input() title: string;

    constructor(private subheader: SubheaderService, private router: Router, private layout: LayoutService,
                private cdr: ChangeDetectorRef) {
        this.subheader.setDefaultSubheader();
        this.subheaderVersion$ = this.subheader.subheaderVersionSubject.asObservable();

        const initSubheader = () => {
            setTimeout(() => {
                this.subheader.updateAfterRouteChanges(this.router.url);
            }, 0);
        };

        initSubheader();
        // subscribe to router events
        this.router.events
            .pipe(filter((event) => event instanceof ResolveEnd))
            .subscribe(initSubheader);

        this.title$ = this.subheader.titleSubject.asObservable();
    }

    ngOnInit(): void {
        this.title$ = this.subheader.titleSubject.asObservable();
        this.breadcrumbs$ = this.subheader.breadCrumbsSubject.asObservable();
        this.description$ = this.subheader.descriptionSubject.asObservable();
        this.subheaderCSSClasses = this.layout.getStringCSSClasses('subheader');
        this.subheaderContainerCSSClasses = this.layout.getStringCSSClasses(
            'subheader_container'
        );
        this.subheaderMobileToggle = this.layout.getProp('subheader.mobileToggle');
        this.subheaderDisplayDesc = this.layout.getProp('subheader.displayDesc');
        this.subheaderDisplayDaterangepicker = this.layout.getProp(
            'subheader.displayDaterangepicker'
        );
        this.breadcrumbs$.subscribe((res) => {
            this.breadcrumbs = res;
            this.cdr.detectChanges();
        });
    }

    ngAfterViewInit() {
        KTUtil.ready(() => {
            KTLayoutSubheader.init('kt_subheader');
        });
    }
}
