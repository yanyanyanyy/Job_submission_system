<template>
  <div class="studentHome">
  <!--本页面是学生登录之后的第一个页面，-->
      <div class="relative">
          <div class="studentImg">
              <h1>xx同学欢迎您!!</h1>
          </div>
      
          <div class="bottom">
              <div class="flex justify-space-between mb-4 flex-wrap gap-4">
                <router-link to="/StudentCorrectListPage">
                        <el-button :key="buttons[0].text"
                                   :type="buttons[0].type"
                                   text
                                   bg>{{ buttons[0].text }}</el-button>
                    </router-link>
                    <span width="10vw"></span>
                    <router-link to="/TeacherRealeasePage">
                        <el-button :key="buttons[1].text"
                                   :type="buttons[1].type"
                                   text
                                   bg>{{ buttons[1].text }}</el-button>
                    </router-link>
              </div>
          </div>
      </div>
  </div>
  </template>
  
  
  <script>
      export default {
          data() {
              return {
                  buttons:[
                      //点击后跳转到已经提交的作业页面
                      { type: 'warning', text: '已提交作业' },
                      //点击后跳转到新发布的作业页面
                      { type: 'warning', text: '新发布作业' },
                  ] 
              }
          }
      }
  </script>
  
  <style lang="scss" scoped>
      .studentHome {
          position: absolute;
          width: 100%;
          height: 100%;
          background-image: url('../../public/images/svgs/login-bg.svg');

          .relative {
              width: 100%;
              height: 100%;
              text-align: center;

              .studentImg {
                  margin-left: auto;
                  margin-right: auto;
                  margin-top: 100px;
                  line-height: 300px;
                  width: 475px;
                  height: 325px;
                  background-image: url("../../public/images/teacherHome.jpg");
                  background-size: contain;

                  h1 {
                      color: white;
                      font-size: 45px;
                  }
              }

              .bottom {
                  position: relative;
                  top: 30px;
              }
          }
      }
  </style>
        