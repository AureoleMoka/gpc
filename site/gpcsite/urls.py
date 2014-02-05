from django.conf.urls import patterns, include, url
from django.contrib import admin
from gpcsite import views

admin.autodiscover()
urlpatterns = patterns('',
        url(r'^$', views.index, name='index'),
        url(r'^gpc/', include('perfgraphs.urls')),
        url(r'^admin/', include(admin.site.urls)),
)
