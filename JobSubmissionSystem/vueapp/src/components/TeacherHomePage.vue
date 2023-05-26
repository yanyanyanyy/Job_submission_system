<template>
    <!--本页面是教师登录之后的第一个页面，实现有批改作业和发布作业两个选项，点击对应的选项会跳转到对应的页面-->
    <div class="teacherHome">
        <div class="relative">
            <div class="teacherImg">
                <h1>xx老师欢迎您!!</h1>
            </div>
        
            <div class="bottom">
                <div class="flex justify-space-between mb-4 flex-wrap gap-4">
                    <el-button
                        v-for="button in buttons"
                        :key="button.text"
                        :type="button.type"
                        text
                        bg
                    >{{ button.text }}</el-button>
                </div>
            </div>
        </div>
    </div> 
    </template>
    
    
    <script lang="ts" setup>
       const buttons = [ 
       //点击后跳转到批改作业页面
        { type: 'warning', text: '批改作业' },
        //点击后跳转到发布作业页面
        { type: 'warning', text: '发布作业' },
        ] as const
    </script>
    
    <style lang="scss" scoped>
    .teacherHome{
        position:absolute;
        width: 100%;
        height: 100%;
        background-image: url('/images/svgs/login-bg.svg');
        .relative{
            width: 100%;
            height: 100%;
            text-align: center;
            .teacherImg{
                margin-left: auto;
                margin-right: auto;
                margin-top: 100px;
                line-height: 300px;
                width:475px;
                height:325px;
                background-image: url("/images/teacherHome.jpg");
                background-size: contain;

                h1{
                    color:white;
                    font-size: 45px;
                }   
            }
            .bottom{
                position:relative;
                top:30px;
            }
        }
    }
    </style>
    